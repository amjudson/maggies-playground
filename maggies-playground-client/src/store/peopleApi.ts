import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export interface PersonType {
    personTypeId: number
    description: string
    clientId: string | null
    name: string
    clientOption: boolean
    createdDate: string
    enteredBy: string
}

export interface Race {
    raceId: number
    description: string
    name: string
    createdDate: string
    enteredBy: string
}

export interface Gender {
    genderId: number
    description: string
    name: string
    createdDate: string
    enteredBy: string
}

export interface Person {
    personId: string
    lastName: string
    firstName: string
    middleName?: string
    suffix?: string
    prefix?: string
    personTypeId: number
    alias: string
    raceId: number
    dateOfBirth: string
    genderId: number
    createdDate: string
    enteredBy: string
    personType: PersonType
    race: Race
    gender: Gender
}

export interface CreatePersonRequest {
    lastName: string
    firstName: string
    middleName?: string
    suffix?: string
    prefix?: string
    personTypeId: number
    alias: string
    raceId: number
    dateOfBirth: string
    genderId: number
}

export interface UpdatePersonRequest extends CreatePersonRequest {
    personId: string
}

export interface PaginatedResponse<T> {
    totalCount: number
    pageSize: number
    currentPage: number
    items: T[]
}

export const peopleApi = createApi({
    reducerPath: 'peopleApi',
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
    tagTypes: ['Person'],
    endpoints: (builder) => ({
        getPeople: builder.query<PaginatedResponse<Person>, { page: number; pageSize: number }>({
            query: ({ page, pageSize }) => ({
                url: '/api/People/GetPeople',
                params: { page, pageSize },
            }),
            transformResponse: (response: PaginatedResponse<Person>) => response,
            providesTags: ['Person'],
        }),
        getPerson: builder.query<Person, string>({
            query: (personId) => `/api/People/GetPerson/${personId}`,
            providesTags: (result, error, id) => [{ type: 'Person', id }],
        }),
        createPerson: builder.mutation<Person, CreatePersonRequest>({
            query: (person) => ({
                url: '/api/People/CreatePerson',
                method: 'POST',
                body: person,
            }),
            invalidatesTags: ['Person'],
        }),
        updatePerson: builder.mutation<Person, UpdatePersonRequest>({
            query: ({ personId, ...person }) => ({
                url: `/api/People/UpdatePerson/${personId}`,
                method: 'PUT',
                body: person,
            }),
            invalidatesTags: (result, error, { personId }) => [{ type: 'Person', id: personId }],
        }),
        deletePerson: builder.mutation<void, string>({
            query: (personId) => ({
                url: `/api/People/DeletePerson/${personId}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['Person'],
        }),
    }),
})

export const {
    useGetPeopleQuery,
    useGetPersonQuery,
    useCreatePersonMutation,
    useUpdatePersonMutation,
    useDeletePersonMutation,
} = peopleApi 