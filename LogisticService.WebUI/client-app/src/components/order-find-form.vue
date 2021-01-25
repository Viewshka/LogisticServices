<template>
  <DxPopup
      height="auto"
      :width="728"
      position="center"
      title="Форма поиска заказа"
      :show-title="true"
      :resize-enabled="true"
      :visible="visible"
      :close-on-outside-click="true"
      @hidden="cancel"
  >
    <div class="find-form">
      <DxTextBox
          v-model:value="currencyValue"
          styling-mode="filled"
          placeholder="Номер заказа"
          :show-clear-button="true"
      >
      </DxTextBox>
      <br>
      <DxButton
          :width="120"
          text="Найти"
          type="default"
          styling-mode="contained"
          @click="submit($event)"
      />
      <br>
      <div v-if="orderInfo">
        <span>{{ orderInfo.message }}</span>
      </div>
    </div>
  </DxPopup>
</template>

<script>
import {DxPopup} from 'devextreme-vue/popup';
import {DxTextBox,} from 'devextreme-vue/text-box';
import notify from 'devextreme/ui/notify';
import DxButton from 'devextreme-vue/button';


export default {
  name: "order-find-form",
  props: {
    visible: {
      type: Boolean,
      required: true
    },
  },
  computed: {
    form: function () {
      return this.$refs[this.formRefName].instance;
    },
  },

  data: function () {
    return {
      popupVisible: false,
      formRefName: 'form',
      currencyValue: null,
      orderInfo: null,
    }
  },
  methods: {
    cancel: function () {
      this.$emit('update:visible', false);
    },

    submit: function () {
      this.orderInfo = {message: 'Поиск начат...'};
      // this.$emit('submit', this.formData);
    },
  },
  components: {
    DxPopup,
    DxTextBox,
    DxButton,
  },
}
</script>

<style>
.find-form {
  align-self: center;
  justify-content: center;
  text-align: center;
}
</style>