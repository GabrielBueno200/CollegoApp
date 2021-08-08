import { AxiosRequestConfig } from "axios";

export const setApiTokenHeaders = (config: AxiosRequestConfig) => {
    const accessToken = window.localStorage.getItem('accessToken');

    if (accessToken) 
        config.headers.Authorization = `Bearer ${accessToken}`;
};