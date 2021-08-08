import axios, { AxiosResponse } from 'axios';
import { setApiErrors } from './responseConfigs';
import { setApiTokenHeaders } from './requestConfigs';

const api = axios.create({ baseURL: 'https://localhost:5001/api' });

api.interceptors.request.use(config => {

        setApiTokenHeaders(config);

        return config;

    }, error => Promise.reject(error)
);

api.interceptors.response.use(undefined, error => { 
    
    setApiErrors(error);

    return Promise.reject(error);
});


/* Own Methods */
const responseBody = <T> (response: AxiosResponse<T>) => response.data;

export default class Requestable{

    static get = <T> (url: string) => api.get<T>(url).then(responseBody);

    static post = <DTO, T = void> (url: string, body: DTO) => api.post<T>(url, body).then(responseBody);

    static put = <T> (url: string, body: T) => api.put(url, body).then(responseBody);

    static delete = (url: string) => api.delete(url).then(responseBody);

};