export const storeTokens = (accessToken: string, refreshToken: string) => {
    window.localStorage.setItem('accessToken', accessToken);
    window.localStorage.setItem('refreshToken', refreshToken);
};

export const destroyTokens = () => {
    window.localStorage.removeItem('accessToken');
    window.localStorage.removeItem('refreshToken');
};