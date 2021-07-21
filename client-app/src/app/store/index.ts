import { useDispatch } from 'react-redux';
import { applyMiddleware, createStore, Store } from 'redux';
import thunk, { ThunkAction, ThunkDispatch, ThunkMiddleware } from 'redux-thunk';
import rootReducer, { AppActions } from './reducers'


export type AsyncAction = ThunkAction<void, AppState, undefined, AppActions>;

export type AppState = ReturnType<typeof rootReducer>;

const store: Store<AppState> = createStore(
    rootReducer,
    applyMiddleware(thunk as ThunkMiddleware<AppState, AppActions>)
);

export const dispatch = store.dispatch as ThunkDispatch<AppState, undefined, AppActions>

export default store;

