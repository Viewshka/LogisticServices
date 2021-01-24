<template>
  <header class="header-component">
    <DxToolbar class="header-toolbar">
      <DxItem
          location="before"
      >
        <DxButton
            icon="menu"
            styling-mode="outlined"
            text="ButtonText"
            slot-scope="_"
        />
      </DxItem>

      <DxItem
          v-if="!user.isAuthenticated"
          location="before"
      >
        <DxButton
            icon="user"
            styling-mode="outlined"
            text="Войти"
            @click="logIn($event)"
            slot-scope="_"
        />
      </DxItem>
      <DxItem
          v-else
          location="before"
      >
        <DxButton
            icon="user"
            styling-mode="outlined"
            :text="`Выйти ${user.userName}`"
            @click="logOut($event)"
            slot-scope="_"
        />
      </DxItem>
    </DxToolbar>
  </header>
</template>

<script>
import DxButton from "devextreme-vue/button";
import DxToolbar, {DxItem} from "devextreme-vue/toolbar";
import DxScrollView from "devextreme-vue/scroll-view";
import auth from "../../auth";

export default {
  name: "NavBar",
  props: {
    title: String,
  },
  data() {
    return {
      user: { },
    }
  },
  created() {
    auth.getUser().then((e) => this.user = e.data);
  },
  methods:{
    async logIn(e) {
      console.log('login click')
      await this.$router.push({
        path: "/login-form",
        query: { redirect: this.$route.path }
      });
    },
    async logOut(e) {
      auth.logOut();
      await this.$router.push({
        path: "/login-form",
        query: { redirect: this.$route.path }
      });
    },
  },
  computed: {},
  components: {
    DxToolbar,
    DxItem,
    DxScrollView,
    DxButton
  }
}
</script>

<style lang="scss">
@import "../../themes/generated/variables.base.scss";
@import "../../dx-styles";

.header-component {
  flex: 0 0 auto;
  z-index: 1;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);

  .dx-toolbar .dx-toolbar-item.menu-button > .dx-toolbar-item-content .dx-icon {
    color: $base-accent;
  }
}

.dx-toolbar {
  background-color: #333 !important;
}

.dx-toolbar.header-toolbar .dx-toolbar-items-container .dx-toolbar-after {
  padding: 0 40px;

  .screen-x-small & {
    padding: 0 20px;
  }
}

.dx-toolbar .dx-toolbar-item.dx-toolbar-button.menu-button {
  //width: $side-panel-min-width;
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
    padding: 3px;
  }
}

.dx-button-text {
  color: white !important;
}

.dx-icon {
  color: white !important;
}

</style>