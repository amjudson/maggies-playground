import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { RootState } from '../../store/store';
import { logout } from '../../store/authSlice';
import './Sidebar.scss';

const Sidebar: React.FC = () => {
    const { isAuthenticated, user } = useSelector((state: RootState) => state.auth);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const handleLogin = () => {
        navigate('/login');
    };

    const handleRegister = () => {
        navigate('/register');
    };

    const handleLogout = () => {
        localStorage.removeItem('token');
        dispatch(logout());
        navigate('/');
    };

    const displayName = user ? `${user.firstName} ${user.lastName}`.trim() || user.email : '';

    return (
        <div className="sidebar">
            <div className="sidebar__title">Maggie's Playground</div>
            <div className="sidebar__nav">
                {!isAuthenticated ? (
                    <>
                        <button className="sidebar__button" onClick={handleLogin}>Login</button>
                        <button className="sidebar__button" onClick={handleRegister}>Register</button>
                    </>
                ) : (
                    <button className="sidebar__button" onClick={handleLogout}>Logout</button>
                )}
            </div>
            {isAuthenticated && user && (
                <div className="sidebar__user-info">
                    <div className="sidebar__user-name">{displayName}</div>
                    <div className="sidebar__user-email">{user.email}</div>
                </div>
            )}
        </div>
    );
};

export default Sidebar; 