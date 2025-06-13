import React from 'react'
import { useGetPeopleQuery, Person } from '../../store/peopleApi'
import { useGetPersonTypesQuery } from '../../store/lookupApi'
import './PeopleList.scss'

const PeopleList: React.FC = () => {
    const { data: people, isLoading: isLoadingPeople, error: peopleError } = useGetPeopleQuery()
    const { data: personTypes, isLoading: isLoadingTypes } = useGetPersonTypesQuery()

    const isLoading = isLoadingPeople || isLoadingTypes
    const error = peopleError

    if (isLoading) {
        return <div className='people-list__loading'>Loading people...</div>
    }

    if (error) {
        return <div className='people-list__error'>Error loading people</div>
    }

    const getPersonTypeName = (personTypeId: number): string => {
        const personType = personTypes?.find(pt => pt.personTypeId === personTypeId)
        return personType?.name || 'Unknown Type'
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
                        </tr>
                    </thead>
                    <tbody>
                        {people?.map((person) => (
                            <tr key={person.personId}>
                                <td>{formatFullName(person)}</td>
                                <td>{person.alias}</td>
                                <td>{new Date(person.dateOfBirth).toLocaleDateString()}</td>
                                <td>{getPersonTypeName(person.personTypeId)}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default PeopleList 