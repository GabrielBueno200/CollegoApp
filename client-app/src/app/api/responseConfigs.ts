import { toast } from 'react-toastify';

export const setApiErrors = (error: any) => {
    const {status, data, config} = error.response;

    if (status === 500 || 
        (error.message === 'Network Error' || error.message === "Connection Refused" && !error.response)){
        toast.error('Ocorreu algum erro interno no nosso servidor!')
    }
};
