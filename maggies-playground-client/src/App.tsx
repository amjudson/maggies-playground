import React from 'react'
import { Provider } from 'react-redux'
import { BrowserRouter } from 'react-router-dom'
import { store } from './store/store'
import AppRoutes from './routes/AppRoutes'
import './App.scss'
import 'bootstrap-icons/font/bootstrap-icons.min.css'

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
