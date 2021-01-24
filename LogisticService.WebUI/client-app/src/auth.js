import 'whatwg-fetch'

export default {
    _user: null,
    loggedIn() {
        return !!this._user;
    },

    async logIn(email, password) {
        return fetch('api/account/login', {
            method: "POST",
            credentials: 'include',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({userName: email, password: password, rememberMe: false})
        })
            .then(() => {
                this._user = null;
                return {
                    isOk: true,
                };
            }).catch(c => {
                console.log(c)
                return {
                    isOk: false,
                    message: "Ошибка авторизации"
                };
            });
    },

    async logOut() {
        return fetch('api/account/logout', {
            method: "POST",
            credentials: 'include',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
        })
            .then(() => {
                this._user = null;
                return {
                    isOk: true,
                    message: "Вы вышли из системы"
                };
            }).catch(c => {
                console.log(c)
                return {
                    isOk: false,
                    message: "Возникла ошибка выхода из системы"
                };
            });
    },

    async getUser() {
        return fetch('api/user/current-user', {
            method: "GET",
            credentials: 'include',
        })
            .then(res => res.json())
            .then(res => {
                console.log('auth get user', res)
                this._user = res;
                return {
                    isOk: true,
                    data: this._user
                };
            })
            .catch(c => {
                console.log(c)
                return {
                    isOk: false
                };
            });
    },

    async resetPassword(email) {
        try {
            // Send request
            console.log(email);

            return {
                isOk: true
            };
        } catch {
            return {
                isOk: false,
                message: "Failed to reset password"
            };
        }
    },

    async changePassword(email, recoveryCode) {
        try {
            // Send request
            console.log(email, recoveryCode);

            return {
                isOk: true
            };
        } catch {
            return {
                isOk: false,
                message: "Failed to change password"
            }
        }
    },

    async createAccount(email, password) {
        try {
            // Send request
            console.log(email, password);

            return {
                isOk: true
            };
        } catch {
            return {
                isOk: false,
                message: "Failed to create account"
            };
        }
    }
};