import React from 'react'
import {useNavigate} from 'react-router-dom'
import {logout} from '../../store/authSlice'
import './Sidebar.scss'
import {
    useAppDispatch,
    useAppSelector,
} from '../../store/hooks'
import {Login, PersonAdd, Logout} from '@mui/icons-material'
import IconButton from '@mui/material/IconButton'
import SunnyIcon from '@mui/icons-material/Sunny'
import NightlightRoundIcon from '@mui/icons-material/NightlightRound'
import { toggleTheme } from '../../store/themeSlice'

const Sidebar: React.FC = () => {
    const navigate = useNavigate()
    const { isAuthenticated, user } = useAppSelector(state => state.auth)
    const theme = useAppSelector((state) => state.theme.currentTheme)
    // console.log('Sidebar state:', { isAuthenticated, user })

    const dispatch = useAppDispatch()

    const handleHomeClick = () => {
        navigate('/')
    }

    const handleLogin = () => {
        navigate('/login')
    }

    const handleRegister = () => {
        navigate('/register')
    }

    const handleLogout = () => {
        sessionStorage.removeItem('token')
        dispatch(logout())
        navigate('/')
    }

    const handleClientListClick = () => {
        navigate('/clients')
    }

    const handlePeopleListClick = () => {
        navigate('/people')
    }

    const handleToggleTheme = () => {
        dispatch(toggleTheme())
    }

    const displayName = user ? `${user.firstName} ${user.lastName}`.trim() || user.email : ''

    return (

        <div className='sidebar'>
            <IconButton
              onClick={handleToggleTheme}
              aria-label={theme === 'theme-light' ? 'Switch to dark mode' : 'Switch to light mode'}
              className={'icon-button'}
              style={{
                  width: '2rem',
                  height: '2rem',
                  background: 'none',
                  color: '#8e44ad',
                  border: '1px solid #8e44ad',
                  borderRadius: '16px',
                  padding: '1px',
                  transition: 'background 0.2s, color 0.2s',
                  flexShrink: '0',
              }}
            >
                {theme === 'theme-light' ? <NightlightRoundIcon /> : <SunnyIcon />}
            </IconButton>
            <div className='sidebar__header' style={{ display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
                <div className='sidebar__title' onClick={handleHomeClick} style={{ cursor: 'pointer' }}>Maggie&apos;s Playground</div>
            </div>
            {isAuthenticated && (
                <div className='sidebar__content'>
                    <ul className='sidebar__list'>
                        <li onClick={handleClientListClick} className='sidebar__list-item'>
                            <i className='bi bi-bank'></i> Client List
                        </li>
                        <li onClick={handlePeopleListClick} className='sidebar__list-item'>
                            <i className='bi bi-people'></i> People List
                        </li>
                    </ul>
                </div>
            )}
            <div className='sidebar__footer'>
                {!isAuthenticated ? (
                    <>
                        <button className='sidebar__button' onClick={handleLogin}>
                            <Login />
                            Login
                        </button>
                        <button className='sidebar__button' onClick={handleRegister}>
                            <PersonAdd />
                            Register
                        </button>
                    </>
                ) : (
                    <>
                        {user && (
                            <div className='sidebar__user-info'>
                                <div className='sidebar__user-name'>{displayName}</div>
                                <div className='sidebar__user-email'>{user.email}</div>
                            </div>
                        )}
                        <button className='sidebar__button' onClick={handleLogout}>
                            <Logout />
                            Logout
                        </button>
                    </>
                )}
            </div>
        </div>
    )
}

export default Sidebar 