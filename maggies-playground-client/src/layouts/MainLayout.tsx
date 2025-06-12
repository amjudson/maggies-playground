import React from 'react'
import Sidebar from '../components/Sidebar/Sidebar'

interface MainLayoutProps {
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className='app'>
            <Sidebar />
            <main className='main-content'>
                {children}
            </main>
        </div>
    )
}

export default MainLayout 