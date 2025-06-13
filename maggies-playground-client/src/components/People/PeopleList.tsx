import React, { useState } from 'react'
import { useGetPeopleQuery, Person } from '../../store/peopleApi'
import Pagination from '../common/Pagination/Pagination'
import './PeopleList.scss'

const PeopleList: React.FC = () => {
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(10)

    const { data: peopleResponse, isLoading: isLoadingPeople, error: peopleError } = useGetPeopleQuery({
        page,
        pageSize,
    })

    const isLoading = isLoadingPeople
    const error = peopleError

    if (isLoading) {
        return <div className='people-list__loading'>Loading people...</div>
    }

    if (error) {
        return <div className='people-list__error'>Error loading people</div>
    }

    const formatFullName = (person: Person): string => {
        const parts = [
            person.prefix,
            person.firstName,
            person.middleName,
            person.lastName,
            person.suffix,
        ].filter(Boolean)
        return parts.join(' ')
    }

    const handlePageChange = (newPage: number) => {
        setPage(newPage)
    }

    const handlePageSizeChange = (newPageSize: number) => {
        setPageSize(newPageSize)
        setPage(1) // Reset to first page when changing page size
    }

    return (
        <div className='people-list'>
            <div className='people-list__header'>
                <h1>People List</h1>
            </div>
            <div className='people-list__table-container'>
                <table className='people-list__table'>
                    <thead>
                        <tr>
                            <th>Full Name</th>
                            <th>Alias</th>
                            <th>Date of Birth</th>
                            <th>Person Type</th>
                            <th>Race</th>
                            <th>Gender</th>
                            <th>Created Date</th>
                            <th>Entered By</th>
                        </tr>
                    </thead>
                    <tbody>
                        {peopleResponse?.items.map((person) => (
                            <tr key={person.personId}>
                                <td>{formatFullName(person)}</td>
                                <td>{person.alias}</td>
                                <td>{new Date(person.dateOfBirth).toLocaleDateString()}</td>
                                <td>{person.personType.name}</td>
                                <td>{person.race.name}</td>
                                <td>{person.gender.name}</td>
                                <td>{new Date(person.createdDate).toLocaleDateString()}</td>
                                <td>{person.enteredBy}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <Pagination
                totalCount={peopleResponse?.totalCount || 0}
                pageSize={peopleResponse?.pageSize || pageSize}
                currentPage={peopleResponse?.currentPage || page}
                onPageChange={handlePageChange}
                onPageSizeChange={handlePageSizeChange}
            />
        </div>
    )
}

export default PeopleList 