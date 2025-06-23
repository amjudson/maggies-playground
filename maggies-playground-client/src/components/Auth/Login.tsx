import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { useLoginMutation } from '../../store/authApi'
import { useNavigate, useLocation } from 'react-router-dom'
import { loginSuccess } from '../../store/authSlice'
import './Auth.scss'

const Login: React.FC = () => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState<string | null>(null)
    const navigate = useNavigate()
    const location = useLocation()
    const dispatch = useDispatch()
    
    const [login, { isLoading }] = useLoginMutation()

    // Get success message from location state if it exists
    const successMessage = location.state?.message

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        setError(null)

        try {
            const result = await login({ email, password }).unwrap()
            dispatch(loginSuccess(result))
            navigate('/')
        } catch {
            setError('Invalid email or password')
        }
    }

    return (
        <div className={'auth-container'}>
            <form onSubmit={handleSubmit} className='auth-form'>
                <h2>Login</h2>
                {successMessage && <div className='success-message'>{successMessage}</div>}
                {error && <div className='error-message'>{error}</div>}
                
                <div className='form-group'>
                    <label htmlFor='email'>Email</label>
                    <input
                        type='email'
                        id='email'
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>

                <div className='form-group'>
                    <label htmlFor='password'>Password</label>
                    <input
                        type='password'
                        id='password'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>

                <button type='submit' disabled={isLoading}>
                    {isLoading ? 'Logging in...' : 'Login'}
                </button>
            </form>
        </div>
    )
}

export default Login 