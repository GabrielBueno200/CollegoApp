import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/users/user';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { AsyncAction } from '../../../..';


/**
 *  Action body 
 */
const loadUserAction = (user: IUser): UserActions => ({
    type: UserTypes.LOADED_USER_SUCCESS,
    payload: user
});


const loadUserAsync = (): AsyncAction => async dispatch => {

    try {
        
        dispatch(requestingUser());

        const user: IUser = await api.listUser();

        dispatch(loadUserAction(user));

    }

    catch(ex){

        const error = (ex as AxiosError).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

}

export default loadUserAsync;

