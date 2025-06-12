import React from 'react'
import { useGetClientsQuery } from '../../store/clientsApi'
import { useGetClientTypesQuery } from '../../store/clientTypesApi'
import './ClientList.scss'

const ClientList: React.FC = () => {
    const { data: clients, isLoading: isLoadingClients, error: clientsError } = useGetClientsQuery()
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
                        {clients?.map((client) => (
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
        </div>
    )
}

export default ClientList 