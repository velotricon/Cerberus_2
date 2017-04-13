import { ComboBoxItemContainer }        from './combo.box.item.container';

export class ComboBoxModelContainer {
    constructor(
        public SelectedItemId: string,
        public Items: ComboBoxItemContainer[]
    ) {

        //Columns length check:
        let first_item_length = 0;
        if (Items.length > 0) {
            first_item_length = Items[0].Columns.length;
        }
        for (let item of Items) {
            if (item.Columns.length != first_item_length) {
                throw new Error("Uneven items column length in ComboBoxModelContainer!");
            }
        }
    }
}