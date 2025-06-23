import { configureStore } from '@reduxjs/toolkit'
import authReducer from './authSlice'
import { authApi } from './authApi'
import { clientsApi } from './clientsApi'
import { clientTypesApi } from './clientTypesApi'
import { peopleApi } from './peopleApi'
import { lookupApi } from './lookupApi'

export const store = configureStore({
    reducer: {
        auth: authReducer,
        [authApi.reducerPath]: authApi.reducer,
        [clientsApi.reducerPath]: clientsApi.reducer,
        [clientTypesApi.reducerPath]: clientTypesApi.reducer,
        [peopleApi.reducerPath]: peopleApi.reducer,
        [lookupApi.reducerPath]: lookupApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(
            authApi.middleware,
            clientsApi.middleware,
            clientTypesApi.middleware,
            peopleApi.middleware,
            lookupApi.middleware,
        ),
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch; 