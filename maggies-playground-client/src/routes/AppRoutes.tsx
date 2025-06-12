import React from 'react'
import { Routes, Route, Navigate } from 'react-router-dom'
import MainLayout from '../layouts/MainLayout'
import Login from '../components/Auth/Login'
import Register from '../components/Auth/Register'
import ClientList from '../components/Clients/ClientList'

const AppRoutes: React.FC = () => {
    return (
        <Routes>
            {/* Public routes */}
            <Route path='/login' element={<Login />} />
            <Route path='/register' element={<Register />} />
            
            {/* Protected routes with sidebar */}
            <Route
                path='/'
                element={
                    <MainLayout>
                        <h1>Welcome to Maggie&apos;s Playground</h1>
                        <p>Your new application is ready to be built!</p>
                    </MainLayout>
                }
            />
            <Route
                path='/clients'
                element={
                    <MainLayout>
                        <ClientList />
                    </MainLayout>
                }
            />
            
            {/* Catch all route - redirect to home */}
            <Route path='*' element={<Navigate to='/' replace />} />
        </Routes>
    )
}

export default AppRoutes 