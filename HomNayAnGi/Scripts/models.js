function Step(content, order) {
    this.id = 0;
    this.content = content;
    this.order = order;
    this.recipeId = 0;
}

//function Step(model) {
//    this.id = model.id;
//    this.content = model.content;
//    this.order = model.order;
//    this.recipeId = model.recipeId;
//}

function Ingredient(material, unit, quantity) {
    this.MaterialId = material;
    this.UnitId = unit;
    this.Quantity = quantity;
}
