import { Reducer } from "redux";
import { UserActions, UserTypes } from "./actions";
import IUserState from "./models/state";

const initialState: IUserState = {
    data: {},
    pending: false,
};

const UserReducer: Reducer<IUserState> = (state = initialState, action: UserActions) => {

    switch (action.type){

        case UserTypes.USER_PENDING :
            return { ...state, pending: true };
        
        case UserTypes.USER_FAIL :
            return { ...state, error: action.payload, pending: false };
            
        case UserTypes.LOADED_USER_SUCCESS :
            return { ...state, data: action.payload, pending: false };

        case UserTypes.USER_REGISTERED_SUCCESS :
            return { ...state, pending: false };

        case UserTypes.USER_EXIT_SUCCESS :
            return { ...state, pending: false, user: {}};
        
        default:
            return state;
    }

};

export default UserReducer;