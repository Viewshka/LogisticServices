<template>
  <div>
    <DxDataGrid
      :data-source="dataSource"
      :focused-row-enabled="true"
      :focused-row-index="0"
      key-expr="id"
    >
      <DxColumn
        data-field="id"
      />
      <DxColumn
          data-field="name"
      />
    </DxDataGrid>
  </div>
</template>

<script>
import DxDataGrid, {DxColumn} from 'devextreme-vue/data-grid'

export default {
  name: 'Home',
  data() {
    return {
      dataSource: [
        {
          id: 1,
          name: 'First'
        },
        {
          id: 2,
          name: 'Second'
        },
        {
          id: 3,
          name: 'Third'
        },
      ]
    }
  },
  components: {
    DxDataGrid,
    DxColumn
  }
}
</script>
