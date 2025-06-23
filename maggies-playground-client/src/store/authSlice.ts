import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { AuthResponse } from './authApi'

interface AuthState {
    isAuthenticated: boolean;
    token: string | null;
    user: AuthResponse['user'] | null;
    error: string | null;
}

// Initialize state from sessionStorage if available
const getInitialState = (): AuthState => {
    const token = sessionStorage.getItem('token')
    const user = sessionStorage.getItem('user')
    
    return {
        isAuthenticated: !!token,
        token: token,
        user: user ? JSON.parse(user) : null,
        error: null,
    }
}

const authSlice = createSlice({
    name: 'auth',
    initialState: getInitialState(),
    reducers: {
        loginStart: (state: AuthState) => {
            state.error = null
        },
        loginSuccess: (state: AuthState, action: PayloadAction<AuthResponse>) => {
            state.isAuthenticated = true
            state.token = action.payload.token
            state.user = action.payload.user
            state.error = null
            
            // Store in sessionStorage
            sessionStorage.setItem('token', action.payload.token)
            sessionStorage.setItem('user', JSON.stringify(action.payload.user))
        },
        loginFailure: (state: AuthState, action: PayloadAction<string>) => {
            state.error = action.payload
        },
        logout: (state: AuthState) => {
            state.isAuthenticated = false
            state.token = null
            state.user = null
            state.error = null
            
            // Clear sessionStorage
            sessionStorage.removeItem('token')
            sessionStorage.removeItem('user')
        },
    },
})

export const { loginStart, loginSuccess, loginFailure, logout } = authSlice.actions
export default authSlice.reducer 