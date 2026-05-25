export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    accessToken: string;
}

export interface RegisterRequest {
    firstName: string;
    lastName?: string; 
    email: string;
    password: string;
    repeatedPassword: string;
}

export interface RegisterResponse {
    userId: string;
    email: string;
}