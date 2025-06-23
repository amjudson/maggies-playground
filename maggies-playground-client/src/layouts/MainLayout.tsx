import React, { useEffect, useState } from 'react'
import Sidebar from '../components/Sidebar/Sidebar'
import IconButton from '@mui/material/IconButton'
import Brightness4Icon from '@mui/icons-material/Brightness4'
import Brightness7Icon from '@mui/icons-material/Brightness7'

interface MainLayoutProps {
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    const [theme, setTheme] = useState('theme-light')

    useEffect(() => {
        const savedTheme = localStorage.getItem('theme')
        if (savedTheme) {
            setTheme(savedTheme)
        }
    }, [])

    useEffect(() => {
        localStorage.setItem('theme', theme)
    }, [theme])

    const toggleTheme = () => {
        setTheme(theme === 'theme-light' ? 'theme-dark' : 'theme-light')
    }

    return (
        <div className={`app ${theme}`}>
          <IconButton
            onClick={toggleTheme}
            aria-label={theme === 'theme-light' ? 'Switch to dark mode' : 'Switch to light mode'}
            style={{
              position: 'absolute',
              top: 20,
              left: 20,
              zIndex: 10,
              background: 'none',
              color: '#8e44ad',
              border: '2px solid #8e44ad',
              borderRadius: 20,
              padding: 4,
              transition: 'background 0.2s, color 0.2s',
            }}
          >
            {theme === 'theme-light' ? <Brightness4Icon /> : <Brightness7Icon />}
          </IconButton>
          <Sidebar />
            <main className='main-content' style={{ position: 'relative' }}>
                {children}
            </main>
        </div>
    )
}

export default MainLayout 