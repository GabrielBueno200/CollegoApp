export interface IAuthenticationResult {
    authenticated: boolean;
    created: string;
    expiry: string;
    refreshToken: string;
    accessToken: string;
};