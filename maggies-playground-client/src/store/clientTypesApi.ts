import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export interface ClientType {
    clientTypeId: number;
    name: string;
    description: string;
    active: boolean;
}

export const clientTypesApi = createApi({
    reducerPath: 'clientTypesApi',
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
    tagTypes: ['ClientType'],
    endpoints: (builder) => ({
        getClientTypes: builder.query<ClientType[], void>({
            query: () => '/api/ClientTypes/GetClientTypes',
            providesTags: ['ClientType'],
        }),
        getClientType: builder.query<ClientType, number>({
            query: (clientTypeId) => `/api/ClientTypes/GetClientType/${clientTypeId}`,
            providesTags: (result, error, id) => [{ type: 'ClientType', id }],
        }),
    }),
})

export const {
    useGetClientTypesQuery,
    useGetClientTypeQuery,
} = clientTypesApi 