import 'whatwg-fetch'

const defaultUser = {
    email: null,
    isAuthenticated: false,
    userId: 0,
    userName: 'Гость'
};

export default {
    _user: defaultUser,
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
            .then(res => res.json())
            .then(res => {
                this._user = {...defaultUser, res};
                return {
                    isOk: true,
                    data: this._user
                };
            }).catch(c => {
                console.log(c)
                return {
                    isOk: false,
                    message: "Authentication failed"
                };
            });
    },

    async logOut() {
        this._user = null;
    },

    async getUser() {
        return fetch('api/user/current-user', {
            method: "GET",
            credentials: 'include',
        })
            .then(res => res.json())
            .then(res => {
                console.log(res)
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
