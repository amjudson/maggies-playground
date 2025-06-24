import { createSlice, PayloadAction } from '@reduxjs/toolkit'

export type ThemeType = 'theme-light' | 'theme-dark'

interface ThemeState {
    currentTheme: ThemeType
}

const initialState: ThemeState = {
    currentTheme: 'theme-light',
}

const themeSlice = createSlice({
    name: 'theme',
    initialState,
    reducers: {
        setTheme: (state, action: PayloadAction<ThemeType>) => {
            state.currentTheme = action.payload
        },
        toggleTheme: (state) => {
            state.currentTheme = state.currentTheme === 'theme-light' ? 'theme-dark' : 'theme-light'
        },
    },
})

export const { setTheme, toggleTheme } = themeSlice.actions
export default themeSlice.reducer 