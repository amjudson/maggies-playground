import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../store/store';
import './Sidebar.scss';

const Sidebar: React.FC = () => {
    const { isAuthenticated } = useSelector((state: RootState) => state.auth);

    return (
        <div className="sidebar">
            <div className="sidebar__title">Maggie's Playground</div>
            <div className="sidebar__nav">
                {!isAuthenticated ? (
                    <>
                        <button className="sidebar__button">Login</button>
                        <button className="sidebar__button">Register</button>
                    </>
                ) : (
                    <button className="sidebar__button">Logout</button>
                )}
            </div>
        </div>
    );
};

export default Sidebar; 