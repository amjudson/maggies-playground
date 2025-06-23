import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export interface Race {
    raceId: number;
    description: string;
    name: string;
    createdDate: string;
    enteredBy: string;
}

export interface Gender {
    genderId: number;
    description: string;
    name: string;
    createdDate: string;
    enteredBy: string;
}

export interface PersonType {
    personTypeId: number;
    description: string;
    clientId?: string;
    name: string;
    clientOption: boolean;
    createdDate: string;
    enteredBy: string;
}

export const lookupApi = createApi({
    reducerPath: 'lookupApi',
    baseQuery: fetchBaseQuery({
        baseUrl: process.env.REACT_APP_BASE_API_URL,
        prepareHeaders: (headers) => {
            const token = sessionStorage.getItem('token')
            if (token) {
                headers.set('authorization', `Bearer ${token}`)
            }
            return headers
        },
    }),
    tagTypes: ['Race', 'Gender', 'PersonType'],
    endpoints: (builder) => ({
        getRaces: builder.query<Race[], void>({
            query: () => '/api/Races/GetRaces',
            providesTags: ['Race'],
        }),
        getGenders: builder.query<Gender[], void>({
            query: () => '/api/Genders/GetGenders',
            providesTags: ['Gender'],
        }),
        getPersonTypes: builder.query<PersonType[], void>({
            query: () => '/api/PersonTypes/GetPersonTypes',
            providesTags: ['PersonType'],
        }),
    }),
})

export const {
    useGetRacesQuery,
    useGetGendersQuery,
    useGetPersonTypesQuery,
} = lookupApi 