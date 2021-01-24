<template>
  <header class="header-component">
    <DxToolbar class="header-toolbar">
      <DxItem
          locate-in-menu="auto"
          location="before"
      >
        <DxButton
            icon="home"
            styling-mode="text"
            text="Главная"
            slot-scope="_"
            @click="()=> $router.push('/home')"
        />
      </DxItem>

      <DxItem
          locate-in-menu="auto"
          location="before"
      >
        <DxButton
            icon="find"
            styling-mode="text"
            text="Отследить заказ"
            slot-scope="_"
            @click="findOrder"
        />
      </DxItem>

      <DxItem
          locate-in-menu="auto"
          location="after"
      >
        <DxButton
            v-if="user"
            icon="cart"
            styling-mode="text"
            text="Мои заказы"
            slot-scope="_"
            @click="()=> $router.push('/cart')"
        />
      </DxItem>
      <DxItem
          location="after"
          locate-in-menu="auto"
      >
        <DxButton
            v-if="!user"
            icon="user"
            class="user-button authorization"
            height="100%"
            styling-mode="outlined"
            text="Войти"
            @click="logIn($event)"
            slot-scope="_"
        />
        <DxButton
            v-else
            icon="user"
            class="user-button authorization"
            height="100%"
            styling-mode="outlined"
            :text="`Выйти ${user.userName}`"
            @click="logOut($event)"
            slot-scope="_"
        />
      </DxItem>
    </DxToolbar>
    <OrderFindForm
        :visible.sync="orderFindFormVisible"
    />
  </header>
</template>

<script>
import DxButton from "devextreme-vue/button";
import DxToolbar, {DxItem} from "devextreme-vue/toolbar";
import DxScrollView from "devextreme-vue/scroll-view";
import auth from "../../auth";
import OrderFindForm from "../../components/order-find-form";
import {mapState} from 'vuex';

export default {
  name: "NavBar",
  props: {
    title: String,
  },

  data() {
    return {
      user: null,
      orderFindFormVisible: false,
    }
  },
  created() {
    // this.$store.dispatch('INIT_CURRENT_USER')
    auth.getUser().then((e) => this.user = e.data);
  },
  methods: {
    findOrder() {
      this.orderFindFormVisible=true
    },
    async logIn(e) {
      console.log('login click')
      await this.$router.push({
        path: "/login-form",
        query: {redirect: this.$route.path}
      });
    },
    async logOut(e) {
      auth.logOut();
      await this.$router.push({
        path: "/login-form",
        query: {redirect: this.$route.path}
      });
    },
  },
  computed: {
    // ...mapState(['currentUser',]),
  },
  components: {
    DxToolbar,
    DxItem,
    DxScrollView,
    DxButton,
    OrderFindForm
  }
}
</script>

<style lang="scss">
@import "../../themes/generated/variables.base.scss";
@import "../../dx-styles.scss";

.header-component {
  flex: 0 0 auto;
  z-index: 1;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);

  .dx-toolbar .dx-toolbar-item.menu-button > .dx-toolbar-item-content .dx-icon {
    color: $base-accent;
  }
}

.dx-toolbar.header-toolbar .dx-toolbar-items-container .dx-toolbar-after {
  padding: 0 40px;

  .screen-x-small & {
    padding: 0 20px;
  }
}

.dx-toolbar .dx-toolbar-item.dx-toolbar-button.menu-button {
  width: $side-panel-min-width;
  text-align: center;
  padding: 0;
}

.header-title .DxItem-content {
  padding: 0;
  margin: 0;
}

.dx-theme-generic {
  .dx-toolbar {
    padding: 10px 0;
  }

  .user-button > .dx-button-content {
    //padding: 3px;
  }
}
</style>