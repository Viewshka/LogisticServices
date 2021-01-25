<template>
  <div>
    <h2 class="content-block">Мои заказы</h2>
    <DxDataGrid
        class="dx-card wide-card cut-dx-component"
        :ref="gridRefName"
        :data-source="dataSource"
        :show-borders="false"
        :focused-row-enabled="true"
        :column-auto-width="true"
        :column-hiding-enabled="true"
        :word-wrap-enabled="true"
        :row-alternation-enabled="false"
        :allow-column-reordering="true"
        :remote-operations="false"

        :focused-row-key.sync="buttonNavigateOptions.focusedRowKey"

        :repaint-changes-only="true"
        :highlight-changes="true"

        :allow-column-resizing="true"

        @focused-row-changed="focusedRowChanged"
        @toolbar-preparing="toolbarPreparing($event)"
        @context-menu-preparing="contextMenuPreparing($event)"
    >
      <DxColumn
          :width="90"
          :hiding-priority="6"
          data-field="id"
          :allow-editing="false"
          :visible="false"
      />
      <DxColumn
          data-field="number"
          caption="Номер"
          :hiding-priority="7"
      />
      <DxColumn
          data-field="totalCost"
          caption="Полная цена"
          :hiding-priority="8"
      />

      <DxColumn
          data-field="startPoint"
          caption="Откуда"
          :hiding-priority="8"
      />
      <DxColumn
          data-field="endPoint"
          caption="Куда"
          :hiding-priority="8"
      />

      <DxColumn
          data-field="userId"
          caption="Заказчик (клиент)"
          :hiding-priority="8"
      >
        <DxLookup :data-source="dataSourceUsers" value-expr="id" display-expr="userName"/>
      </DxColumn>
      <DxColumn
          data-field="serviceTypeId"
          caption="Тип услуги"
          :hiding-priority="8"
      >
        <DxLookup :data-source="dataSourceServices" value-expr="id" display-expr="name"/>
      </DxColumn>
      <DxColumn
          data-field="status"
          caption="Статут"
          :hiding-priority="8"
      >
        <DxLookup :data-source="dataSourceStatuses" value-expr="id" display-expr="name"/>
      </DxColumn>


      <DxColumn
          caption="Управление"
          type="buttons"
          :hiding-priority="10"
          cell-template="buttonControl"
          alignment="center"
      />

      <template #buttonControl="{data}">
        <div class="dx-command-edit dx-command-edit-with-icons">
          <a href="#"
             class="dx-link dx-icon-upload dx-link-icon"
             title="Взять заказ"
             v-on:click="takeOrder(data.data.id)"
          ></a>

          <a href="#"
             class="dx-link dx-icon-edit dx-link-icon"
             title="Отредактировать"
             v-on:click="navigateToOrder(data.data.id)"
          ></a>

          <a href="#"
             class="dx-link dx-icon-trash dx-link-icon"
             title="Удалить заказ"
             v-on:click="deleteOrder(data.data)"
          ></a>
        </div>
      </template>

      <DxStateStoring
          :enabled="true"
          type="localStorage"
          :saving-timeout="0"
          storage-key="awdawdadsasczdvsv"
      />
      <DxSummary>
        <DxGroupItem summary-type="count"/>
      </DxSummary>
      <DxSorting/>
      <DxPaging :page-size="50"/>
      <DxFilterRow :visible="true"/>
      <DxGroupPanel emptyPanelText=" " :visible="true"/>
      <DxLoadPanel :enabled="false"/>
      <DxSearchPanel :visible="true"/>
      <DxGrouping :auto-expand-all="false"/>
      <DxHeaderFilter :visible="true" :allow-search="true"/>
      <DxColumnChooser :enabled="true" mode="select"/>
      <DxScrolling mode="virtual" row-rendering-mode="virtual" column-rendering-mode="virtual"/>

      <template #buttonNavigateToParagraphsTemplate={data}>
        <DxButton
            hint="Посмотреть всю информацию о заказе"
            type="default"
            :disabled="buttonNavigateOptions.disabled"
            :text="buttonNavigateOptions.text"
            @click="navigateToOrder(buttonNavigateOptions.focusedRowKey)"
        />
      </template>
      <template #buttonInsertContractTemplate={data}>
        <DxButton
            hint="Добавить новый заказ"
            text="Добавить заказ"
            type="normal"
            icon="plus"
            @click="insert"
        />
      </template>
    </DxDataGrid>

    <OrderCreateForm
        @submit="submit"
        :visible.sync="formDataOrder.visible"
        :form-data="formDataOrder.data"
    />
    <OrderDetailsForm
        @submit="submitUpdate"
        :visible.sync="formDataOrderDetails.visible"
        :order-id="formDataOrderDetails.orderId"
    />
  </div>
</template>

<script>
import {DxButton,} from 'devextreme-vue'
import DxDataGrid, {
  DxColumn,
  DxFilterRow,
  DxPaging,
  DxSearchPanel,
  DxColumnChooser,
  DxSorting,
  DxHeaderFilter,
  DxStateStoring,
  DxScrolling,
  DxLoadPanel,
  DxGroupPanel,
  DxGrouping,
  DxSummary,
  DxGroupItem,
  DxLookup,
} from "devextreme-vue/data-grid";

import notify from "devextreme/ui/notify";
import {confirm,} from 'devextreme/ui/dialog';
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import OrderCreateForm from "../components/order-create-form";
import OrderDetailsForm from "../components/order-details-form";

const dataSource = AspNetData.createStore({
  key: 'id',
  loadUrl: `/api/order/current-user-orders`,
  onBeforeSend: (method, ajaxOptions) => {
    ajaxOptions.xhrFields = {withCredentials: true};
  },
});
const dataSourceUsers = AspNetData.createStore({
  key: 'id',
  loadUrl: `/api/user/all`,
  onBeforeSend: (method, ajaxOptions) => {
    ajaxOptions.xhrFields = {withCredentials: true};
  },
});
const dataSourceServices = AspNetData.createStore({
  key: 'id',
  loadUrl: `/api/ServiceType`,
  onBeforeSend: (method, ajaxOptions) => {
    ajaxOptions.xhrFields = {withCredentials: true};
  },
});
import axios from 'axios';

export default {
  name: "cart",
  data() {
    return {
      dataSource,
      dataSourceUsers,
      dataSourceServices,
      dataSourceStatuses: [
        {name: 'Отправлен', id: 1},
        {name: 'ПереданНаКомплектацию', id: 2},
        {name: 'Готов', id: 3},
        {name: 'Доставка', id: 4},
        {name: 'Завершен', id: 5},
        {name: 'Отменен', id: 6}
      ],
      blocks: [],
      gridRefName: 'dataGrid',


      formDataOrder: {
        visible: false,
        data: {}
      },
      formDataOrderDetails: {
        visible: false,
        orderId: 0
      },

      buttonNavigateOptions: {
        disabled: true,
        text: 'Перейти к заказу',
        number: '',
        focusedRowKey: null,
      },
    };
  },
  methods: {
    takeOrder(id) {
      console.log(id)
      confirm(`Вы уверены, что хотите взять заказ?`, "Удаление")
          .then((dialogResult) => {
            if (dialogResult) {
              axios.post(`/api/order/take-order/`, {orderId: id})
                  .then(() => {
                    this.refreshDataGrid();
                  })
                  .catch(reason => {
                    console.log(reason)
                  });
            }
          });
    },
    navigateToOrder(id) {
      console.log(id)
      this.formDataOrderDetails.orderId = id;
      this.formDataOrderDetails.visible = true;
    },
    focusedRowChanged(e) {
      if (e.rowIndex > -1 && e.row.rowType === "data") {
        this.buttonNavigateOptions.disabled = false
        this.buttonNavigateOptions.text = `Перейти к заказу (${this.buttonNavigateOptions.focusedRowKey})`

      } else {
        this.buttonNavigateOptions.disabled = true
        this.buttonNavigateOptions.text = 'Перейти к заказу'
      }
    },

    insert() {
      this.formDataOrder.data = {};
      this.formDataOrder.visible = true;
    },
    submit(data) {
      axios.post(`/api/order/`, data)
          .then(() => {
            this.refreshDataGrid();
            this.formDataOrder.visible = false;
          })
          .catch(reason => {
            console.log(reason)
          });
    },
    submitUpdate(data) {
      axios.put(`/api/order/${data.id}`, data)
          .then(() => {
            this.refreshDataGrid();
            this.formDataOrderDetails.visible = false;
          })
          .catch(reason => {
            console.log(reason)
          });
    },
    deleteOrder(data) {
      confirm(`Вы уверены, что хотите удалить заказ <b>'${data.number}'</b>?`, "Удаление")
          .then((dialogResult) => {
            if (dialogResult) {
              axios.delete(`/api/order/remove/${data.id}`)
                  .then(() => {
                    this.refreshDataGrid();
                  })
                  .catch(reason => {
                    console.log(reason)
                  });
            }
          });
    },

    contextMenuPreparing(e) {
      if (e.target !== 'header' && e.target !== 'headerPanel') {
        if (!e.items) e.items = [];

        e.items.push(
            {
              id: 'nevigateTo',
              text: 'Перейти к заказу',
              icon: 'find',
              onItemClick: () => {
                this.navigateToOrder(e.row.data.id)
              }
            },
            {
              id: 'insert',
              text: 'Добавить',
              icon: 'plus',
              onItemClick: () => {
                this.insert()
              }
            },
            {
              id: 'delete',
              text: 'Удалить',
              icon: 'trash',
              onItemClick: () => {
                this.deleteOrder(e.row.data)
              }
            },
        );
      }
    },
    toolbarPreparing(e) {
      e.toolbarOptions.items.unshift(
          {
            location: 'before',
            widget: 'dxButton',
            locateInMenu: 'auto',
            showText: 'auto',
            options: {
              text: 'Перейти к заказу',
              hint: 'Перейти к заказу',
              type: 'default',
              stylingMode: 'contained',
              focusStateEnabled: false,
              onClick: () => {
                if (!this.buttonNavigateOptions.disabled)
                  this.navigateToOrder(this.buttonNavigateOptions.focusedRowKey)
              }
            },
          },
          {
            location: 'after',
            widget: 'dxButton',
            locateInMenu: 'auto',
            showText: 'inMenu',
            options: {
              text: 'Обновить',
              hint: 'Обновить',
              icon: 'refresh',
              type: 'normal',
              stylingMode: 'contained',
              onClick: this.refreshDataGrid.bind(this)
            }
          },
          {
            location: 'after',
            template: 'buttonInsertContractTemplate'
          },)
    },
    async refreshDataGrid() {
      this.$refs[this.gridRefName].instance.refresh();
    },
  },
  components: {
    OrderDetailsForm,
    OrderCreateForm,
    DxDataGrid,
    DxColumn,
    DxFilterRow,
    DxPaging,
    DxSearchPanel,
    DxColumnChooser,
    DxSorting,
    DxHeaderFilter,
    DxStateStoring,
    DxScrolling,
    DxLoadPanel,
    DxGroupPanel,
    DxGrouping,
    DxSummary,
    DxGroupItem,
    DxButton,
    DxLookup,
  },
}
</script>

<style scoped>

</style>