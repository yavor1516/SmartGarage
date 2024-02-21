import { createStore } from 'vuex';

export default createStore({
    state() {
        return {
            isAuthenticated: false,
        };
    },
    mutations: {
        setAuthenticated(state, isAuthenticated) {
            state.isAuthenticated = isAuthenticated;
        },
    },
    actions: {
        checkAuthentication({ commit }) {
            const jwtToken = localStorage.getItem('JwtAcessToken');
            if (jwtToken) {
                commit('setAuthenticated', true);
            } else {
                commit('setAuthenticated', false);
            }
        },
    },
    modules: {},
});
