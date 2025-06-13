import React, { useState } from 'react'
import { useRegisterMutation } from '../../store/authApi'
import { useNavigate } from 'react-router-dom'
import './Auth.scss'

const Register: React.FC = () => {
    const [email, setEmail] = useState('')
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPassword, setConfirmPassword] = useState('')
    const [role, setRole] = useState('User')
    const [error, setError] = useState<string | null>(null)
    const navigate = useNavigate()
    
    const [register, { isLoading }] = useRegisterMutation()

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        setError(null)

        if (password !== confirmPassword) {
            setError('Passwords do not match')
            return
        }

        if (!firstName.trim() || !lastName.trim()) {
            setError('First name and last name are required')
            return
        }

        try {
            await register({ 
                email, 
                password, 
                confirmPassword,
                firstName: firstName.trim(),
                lastName: lastName.trim(),
                role,
            }).unwrap()
            
            // Redirect to login page after successful registration
            navigate('/login', { 
                state: { 
                    message: 'Registration successful! Please log in with your new account.', 
                },
            })
        } catch {
            setError('Registration failed. Please try again.')
        }
    }

    return (
        <div className='auth-container'>
            <form onSubmit={handleSubmit} className='auth-form'>
                <h2>Register</h2>
                {error && <div className='error-message'>{error}</div>}
                
                <div className='form-group'>
                    <input
                        type='text'
                        id='firstName'
                        placeholder='First Name'
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                        required
                    />
                </div>

                <div className='form-group'>
                    <input
                        type='text'
                        id='lastName'
                        placeholder='Last Name'
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                        required
                    />
                </div>

                <div className='form-group'>
                    <input
                        type='email'
                        id='email'
                        placeholder='Email'
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>

                <div className='form-group'>
                    <label htmlFor='role'>Role</label>
                    <select
                        id='role'
                        value={role}
                        onChange={(e) => setRole(e.target.value)}
                        required
                    >
                        <option value='User'>User</option>
                        <option value='Viewer'>Viewer</option>
                        <option value='Admin'>Admin</option>
                        <option value='SuperAdmin'>SuperAdmin</option>
                    </select>
                </div>

                <div className='form-group'>
                    <input
                        type='password'
                        id='password'
                        placeholder='Password'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>

                <div className='form-group'>
                    <input
                        type='password'
                        id='confirmPassword'
                        placeholder='Confirm Password'
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                        required
                    />
                </div>

                <button type='submit' disabled={isLoading}>
                    {isLoading ? 'Registering...' : 'Register'}
                </button>
            </form>
        </div>
    )
}

export default Register 