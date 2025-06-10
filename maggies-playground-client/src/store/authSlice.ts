import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AuthResponse } from './authApi';

interface AuthState {
    isAuthenticated: boolean;
    token: string | null;
    user: AuthResponse['user'] | null;
    error: string | null;
}

const initialState: AuthState = {
    isAuthenticated: false,
    token: null,
    user: null,
    error: null,
};

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        loginStart: (state: AuthState) => {
            state.error = null;
        },
        loginSuccess: (state: AuthState, action: PayloadAction<AuthResponse>) => {
            state.isAuthenticated = true;
            state.token = action.payload.token;
            state.user = action.payload.user;
            state.error = null;
        },
        loginFailure: (state: AuthState, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        logout: (state: AuthState) => {
            state.isAuthenticated = false;
            state.token = null;
            state.user = null;
            state.error = null;
        },
    },
});

export const { loginStart, loginSuccess, loginFailure, logout } = authSlice.actions;
export default authSlice.reducer; 