import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import { RootState } from '../../store/store'
import { logout } from '../../store/authSlice'
import './Sidebar.scss'

const Sidebar: React.FC = () => {
    const { isAuthenticated, user } = useSelector((state: RootState) => state.auth)
    const navigate = useNavigate()
    const dispatch = useDispatch()

    const handleLogin = () => {
        navigate('/login')
    }

    const handleRegister = () => {
        navigate('/register')
    }

    const handleLogout = () => {
        localStorage.removeItem('token')
        dispatch(logout())
        navigate('/')
    }

    const handleClientListClick = () => {
        navigate('/clients')
    }

    const displayName = user ? `${user.firstName} ${user.lastName}`.trim() || user.email : ''

    return (
        <div className='sidebar'>
            <div className='sidebar__title'>Maggie&apos;s Playground</div>
            <div className='sidebar__content'>
                <ul className='sidebar__list'>
                    <li onClick={handleClientListClick} className='sidebar__list-item'>
                        <i className='bi bi-bank'></i> Client List
                    </li>
                </ul>
            </div>
            <div className='sidebar__footer'>
                {!isAuthenticated ? (
                    <>
                        <button className='sidebar__button' onClick={handleLogin}>Login</button>
                        <button className='sidebar__button' onClick={handleRegister}>Register</button>
                    </>
                ) : (
                    <>
                        {user && (
                            <div className='sidebar__user-info'>
                                <div className='sidebar__user-name'>{displayName}</div>
                                <div className='sidebar__user-email'>{user.email}</div>
                            </div>
                        )}
                        <button className='sidebar__button' onClick={handleLogout}>Logout</button>
                    </>
                )}
            </div>
        </div>
    )
}

export default Sidebar 