import { IAuthenticationResult } from "../../models/token/authResult";

export const storeTokens = (tokens: IAuthenticationResult) => {
    window.localStorage.setItem('accessToken', tokens.accessToken);
    window.localStorage.setItem('refreshToken', tokens.refreshToken);
    window.localStorage.setItem('expiry', tokens.expiry);
};

export const destroyTokens = () => {
    window.localStorage.removeItem('accessToken');
    window.localStorage.removeItem('refreshToken');
};