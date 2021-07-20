import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/user';
import { requestUser, failedRequestingUser } from '../default/defaultActions';
import { LoadUserActions, ILoadUserTypes } from './types';
import { default as api } from '../endpoints';


/**
 *  Action body 
 */
const loadUserAction = (user: IUser): LoadUserActions=> ({
    type: ILoadUserTypes.USER_SUCCESS,
    payload: user
});


const loadUserAsync = () => async (dispatch: Dispatch) => {

    try {
        
        dispatch(requestUser());

        const user: IUser = await api.listUser();

        dispatch(loadUserAction(user));

    }

    catch(ex){
        const error = (ex as AxiosError).response?.data;
        
        dispatch(failedRequestingUser(error))
    }

}

