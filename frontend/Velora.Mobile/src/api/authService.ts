import { post } from './apiService';

import type {
    LoginRequest,
    LoginResponse,
    RegisterRequest,
    RegisterResponse
} from '../types/auth';

export async function login(data: LoginRequest) {
    return post<LoginRequest,LoginResponse>('/auth/login', data);
}

export async function register(data: RegisterRequest) {
    return post<RegisterRequest,RegisterResponse>('/auth/register', data);
}