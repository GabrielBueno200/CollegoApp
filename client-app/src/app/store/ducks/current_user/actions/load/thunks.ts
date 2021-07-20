import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/user';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { ILoadUserTypes } from './types';
import { default as api } from '../endpoints';
import { UserActions } from '..';
import { IUserError } from '../default/defaultTypes';


/**
 *  Action body 
 */
const loadUserAction = (user: IUser): UserActions => ({
    type: ILoadUserTypes.USER_SUCCESS,
    payload: user
});


const loadUserAsync = () => async (dispatch: Dispatch<UserActions>) => {

    try {
        
        dispatch(requestingUser());

        const user: IUser = await api.listUser();

        dispatch(loadUserAction(user));

    }

    catch(ex){

        const error = (ex as AxiosError<IUserError>).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

}

