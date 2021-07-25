import { AxiosError } from 'axios';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { ITokens } from '../../../../../models/token/token';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { AsyncAction  } from '../../../..';

/**
 *  Action body 
 */
const userLogoutAction = (): UserActions => ({
    type: UserTypes.USER_EXIT_SUCCESS,
});


export const signOutAsync = (tokens: ITokens):AsyncAction  => async dispatch => {

    try {
        
        dispatch(requestingUser());

        await api.logout(tokens);

        dispatch(userLogoutAction());

    }

    catch(ex){

        const error = (ex as AxiosError).response!.data;
        
        dispatch(failedRequestingUser(error));
    }

};