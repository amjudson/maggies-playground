import React, { useEffect } from 'react'
import Sidebar from '../components/Sidebar/Sidebar'
import { useAppDispatch, useAppSelector } from '../store/hooks'
import { setTheme } from '../store/themeSlice'
import type { ThemeType } from '../store/themeSlice'

interface MainLayoutProps {
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    const dispatch = useAppDispatch()
    const theme = useAppSelector((state) => state.theme.currentTheme)

    useEffect(() => {
        const savedTheme = localStorage.getItem('theme') as ThemeType
        if (savedTheme && (savedTheme === 'theme-light' || savedTheme === 'theme-dark')) {
            dispatch(setTheme(savedTheme))
        } else {
            // Set default theme to light if no theme is present
            dispatch(setTheme('theme-light'))
        }
    }, [dispatch])

    useEffect(() => {
        localStorage.setItem('theme', theme)
    }, [theme])

    return (
        <div className={`app ${theme}`}>
          <Sidebar />
            <main className='main-content' style={{ position: 'relative' }}>
              {children}
            </main>
        </div>
    )
}

export default MainLayout 