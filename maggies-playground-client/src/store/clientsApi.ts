import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export interface Client {
    clientId: string
    clientName: string
    active: boolean
    createdDate: string
    enteredBy: string
    clientTypeId: number
}

export interface CreateClientRequest {
    clientName: string
    active: boolean
    clientTypeId: number
}

export interface UpdateClientRequest extends CreateClientRequest {
    clientId: string
}

export interface PaginatedResponse<T> {
    totalCount: number
    pageSize: number
    currentPage: number
    items: T[]
}

export const clientsApi = createApi({
    reducerPath: 'clientsApi',
    baseQuery: fetchBaseQuery({
        baseUrl: process.env.REACT_APP_BASE_API_URL,
        prepareHeaders: (headers) => {
            const token = localStorage.getItem('token')
            if (token) {
                headers.set('authorization', `Bearer ${token}`)
            }
            return headers
        },
    }),
    tagTypes: ['Client'],
    endpoints: (builder) => ({
        getClients: builder.query<PaginatedResponse<Client>, { page: number; pageSize: number }>({
            query: ({ page, pageSize }) => ({
                url: '/api/Clients/GetClients',
                params: { page, pageSize },
            }),
            transformResponse: (response: PaginatedResponse<Client>) => response,
            providesTags: ['Client'],
        }),
        getClient: builder.query<Client, string>({
            query: (clientId) => `/api/Clients/GetClient/${clientId}`,
            providesTags: (result, error, id) => [{ type: 'Client', id }],
        }),
        createClient: builder.mutation<Client, CreateClientRequest>({
            query: (client) => ({
                url: '/api/Clients/CreateClient',
                method: 'POST',
                body: client,
            }),
            invalidatesTags: ['Client'],
        }),
        updateClient: builder.mutation<Client, UpdateClientRequest>({
            query: ({ clientId, ...client }) => ({
                url: `/api/Clients/UpdateClient/${clientId}`,
                method: 'PUT',
                body: client,
            }),
            invalidatesTags: (result, error, { clientId }) => [{ type: 'Client', id: clientId }],
        }),
        deleteClient: builder.mutation<void, string>({
            query: (clientId) => ({
                url: `/api/Clients/DeleteClient/${clientId}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['Client'],
        }),
    }),
})

export const {
    useGetClientsQuery,
    useGetClientQuery,
    useCreateClientMutation,
    useUpdateClientMutation,
    useDeleteClientMutation,
} = clientsApi 