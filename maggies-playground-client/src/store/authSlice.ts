import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface AuthState {
    isAuthenticated: boolean;
    user: string | null;
    error: string | null;
}

const initialState: AuthState = {
    isAuthenticated: false,
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
        loginSuccess: (state: AuthState, action: PayloadAction<string>) => {
            state.isAuthenticated = true;
            state.user = action.payload;
            state.error = null;
        },
        loginFailure: (state: AuthState, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        logout: (state: AuthState) => {
            state.isAuthenticated = false;
            state.user = null;
            state.error = null;
        },
    },
});

export const { loginStart, loginSuccess, loginFailure, logout } = authSlice.actions;
export default authSlice.reducer; 