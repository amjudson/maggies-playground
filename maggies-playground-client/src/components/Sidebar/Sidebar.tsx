import React from 'react'
import {useNavigate} from 'react-router-dom'
import {logout} from '../../store/authSlice'
import './Sidebar.scss'
import {
    useAppDispatch,
    useAppSelector,
} from '../../store/hooks'
import {Login, PersonAdd, Logout} from '@mui/icons-material'

const Sidebar: React.FC = () => {
    const navigate = useNavigate()
    const { isAuthenticated, user } = useAppSelector(state => state.auth)
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

    const displayName = user ? `${user.firstName} ${user.lastName}`.trim() || user.email : ''

    return (
        <div className='sidebar'>
            <div className='sidebar__title' onClick={handleHomeClick} style={{ cursor: 'pointer' }}>Maggie&apos;s Playground</div>
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