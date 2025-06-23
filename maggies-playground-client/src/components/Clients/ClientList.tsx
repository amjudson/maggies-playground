import React, {useState} from 'react'
import {useGetClientsQuery} from '../../store/clientsApi'
import {useGetClientTypesQuery} from '../../store/clientTypesApi'
import Pagination from '../common/Pagination/Pagination'
import './ClientList.scss'

const ClientList: React.FC = () => {
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(10)

    console.log('ClientList state:', { page, pageSize })

    const { data: clientsResponse, isLoading: isLoadingClients, error: clientsError } = useGetClientsQuery({
        page,
        pageSize,
    })

    console.log('ClientList API response:', clientsResponse)
    const { data: clientTypes, isLoading: isLoadingTypes, error: typesError } = useGetClientTypesQuery()

    const isLoading = isLoadingClients || isLoadingTypes
    const error = clientsError || typesError

    if (isLoading) {
        return <div className='client-list__loading'>Loading clients...</div>
    }

    if (error) {
        return <div className='client-list__error'>Error loading clients</div>
    }

    const getClientTypeName = (clientTypeId: number): string => {
        const clientType = clientTypes?.find(type => type.clientTypeId === clientTypeId)
        return clientType?.name || 'Unknown Type'
    }

    const handlePageChange = (newPage: number) => {
        console.log('ClientList handlePageChange called with:', newPage)
        console.log('ClientList current page before change:', page)
        setPage(newPage)
    }

    const handlePageSizeChange = (newPageSize: number) => {
        console.log('ClientList handlePageSizeChange called with:', newPageSize)
        setPageSize(newPageSize)
        setPage(1) // Reset to first page when changing page size
    }

    return (
        <div className='client-list'>
            <div className='client-list__header'>
                <h1>Client List</h1>
            </div>
            <div className='client-list__table-container'>
                <table className='client-list__table'>
                    <thead>
                        <tr>
                            <th>Client Name</th>
                            <th>Status</th>
                            <th>Created Date</th>
                            <th>Entered By</th>
                            <th>Client Type</th>
                        </tr>
                    </thead>
                    <tbody>
                        {clientsResponse?.items.map((client) => (
                            <tr key={client.clientId} className={!client.active ? 'client-list__row--inactive' : ''}>
                                <td>{client.clientName}</td>
                                <td>
                                    <span className={`client-list__status ${client.active ? 'active' : 'inactive'}`}>
                                        {client.active ? 'Active' : 'Inactive'}
                                    </span>
                                </td>
                                <td>{new Date(client.createdDate).toLocaleDateString()}</td>
                                <td>{client.enteredBy}</td>
                                <td>{getClientTypeName(client.clientTypeId)}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <Pagination
                totalCount={clientsResponse?.totalCount || 0}
                pageSize={pageSize}
                currentPage={page}
                onPageChange={handlePageChange}
                onPageSizeChange={handlePageSizeChange}
            />
        </div>
    )
}

export default ClientList 