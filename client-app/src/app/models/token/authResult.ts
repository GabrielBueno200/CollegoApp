export interface AuthenticationResult {
    authenticated: boolean;
    created: Date;
    expiry: Date;
    refreshToken: string;
    accessToken: string;
};