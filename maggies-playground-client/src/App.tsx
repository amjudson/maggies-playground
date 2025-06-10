import React from 'react'
import { Provider } from 'react-redux'
import { BrowserRouter } from 'react-router-dom'
import { store } from './store/store'
import AppRoutes from './routes/AppRoutes'
import './App.scss'

const App: React.FC = () => {
    return (
        <Provider store={store}>
            <BrowserRouter>
                <AppRoutes />
            </BrowserRouter>
        </Provider>
    )
}

export default App
