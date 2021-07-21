import { default as api, AxiosResponse } from 'axios';

const responseBody = <T> (response: AxiosResponse<T>)=> response.data;

class Requestable{

    static get = <T> (url: string) => api.get<T>(url).then(responseBody);

    static post = <DTO, T = void> (url: string, body: DTO) => api.post<T>(url, body).then(responseBody);

    static put = <T> (url: string, body: T) => api.put(url, body).then(responseBody);

    static delete = (url: string) => api.delete(url).then(responseBody);

};

export default Requestable;