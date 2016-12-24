﻿/*!@license
* Infragistics.Web.ClientUI igCombo KnockoutJS extension 16.2.20162.1035
*
* Copyright (c) 2012-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
* Depends on:
*	jquery-1.9.1.js
*	ig.util.js
*	ig.dataSource.js
*/
(function(factory){if(typeof define==="function"&&define.amd){define(["jquery","jquery-ui","knockout","../modules/infragistics.util","../modules/infragistics.datasource","../modules/infragistics.ui.combo"],factory)}else{factory(jQuery)}})(function($){function selectItems(combo,selectedItems){var valueKey=combo.igCombo("option","valueKey"),selectedValues=[],index,item,value;if(selectedItems){selectedItems=ko.utils.unwrapObservable(selectedItems);for(index=0;index<selectedItems.length;index++){item=selectedItems[index];if(typeof item==="function"){item=item()}if(typeof item==="object"){value=item[valueKey]}else{value=item}selectedValues.push(value)}combo.igCombo("value",selectedValues)}}ko.bindingHandlers.igCombo={init:function(element,valueAccessor){var combo=$(element),options=valueAccessor(),selectedItems=valueAccessor().selectedItems;combo.igCombo(options);ko.applyBindingsToNode(element,{igComboSelection:{selectedItems:selectedItems}},selectedItems);ko.applyBindingsToNode(combo.data("igCombo")._options.$dropDownCont[0],{igComboList:{combo:combo,options:options,dataSource:valueAccessor().dataSource,selectedItems:selectedItems}},valueAccessor().dataSource);ko.utils.registerEventHandler(element,"igcomboselectionchanged",function(evt,ui){var valueKey=ui.owner.options.valueKey,items=ui.items,selectedItems=valueAccessor().selectedItems,selectionType=valueAccessor().selectedItemType,selectedValues=[],item,itemData,firstItem,itemForSelection,index;if(items&&selectedItems&&ko.isObservable(selectedItems)){selectedItems=ko.utils.unwrapObservable(selectedItems);if(!selectionType){if(selectedItems.length>0){firstItem=selectedItems[0];if(typeof firstItem==="function"){firstItem=firstItem()}if(typeof firstItem==="object"){selectionType="object"}else{selectionType="primitive"}}else{selectionType="primitive"}}items=typeof items==="function"?items():items;for(index=0;index<items.length;index++){item=items[index];itemData=item.data;if(typeof itemData==="function"){itemData=itemData()}if(selectionType==="object"){itemForSelection=itemData}else if(selectionType==="primitive"){itemForSelection=itemData[valueKey]}if(typeof itemForSelection==="function"){itemForSelection=itemForSelection()}selectedValues.push(itemForSelection)}}if(ko.isObservable(valueAccessor().selectedItems)){valueAccessor().selectedItems(selectedValues)}})}};ko.bindingHandlers.igComboSelection={update:function(element,valueAccessor){selectItems($(element),valueAccessor().selectedItems)}};ko.bindingHandlers.igComboList={init:function(element,valueAccessor){var combo=valueAccessor().combo,$comboList=combo.igCombo("listItems"),options=valueAccessor().options,dataSource=ko.utils.unwrapObservable(valueAccessor().dataSource),i;if(dataSource){for(i=0;i<$comboList.length;i++){ko.applyBindingsToNode($comboList[i],{igComboItem:{combo:combo,value:dataSource[i],index:i,options:options}},dataSource[i])}}},update:function(element,valueAccessor){var combo=$(valueAccessor().combo),listLength=combo.igCombo("listItems").length,options=valueAccessor().options,dataSource=ko.utils.unwrapObservable(valueAccessor().dataSource),$comboList,i;if(listLength!==dataSource.length){combo.one("igcomboitemsrendered",function(){$comboList=combo.igCombo("listItems");if(dataSource){for(i=0;i<$comboList.length;i++){ko.applyBindingsToNode($comboList[i],{igComboItem:{combo:combo,value:dataSource[i],index:i,options:options}},dataSource[i])}}selectItems(combo,valueAccessor().selectedItems)});combo.igCombo("option","dataSource",dataSource)}}};ko.bindingHandlers.igComboItem={update:function(element,valueAccessor){var combo=valueAccessor().combo,textKey=valueAccessor().options.textKey,valueKey=valueAccessor().options.valueKey,item,index,dsItem;if(valueKey===undefined&&textKey===undefined){return}index=valueAccessor().index;dsItem=valueAccessor().value;item=combo.igCombo("itemsFromIndex",index).element;combo.data("igCombo")._updateItem(item,dsItem);combo.data("igCombo")._updateInputValues()}};ko.bindingHandlers.igComboVisible={update:function(element,valueAccessor){var visible=valueAccessor(),combo=$(element);if(!ko.isObservable(visible)){return}combo.css("display",visible()?"inline-block":"none")}}});(function($){$(document).ready(function(){var wm=$("#__ig_wm__").length>0?$("#__ig_wm__"):$("<div id='__ig_wm__'></div>").appendTo(document.body);wm.css({position:"fixed",bottom:0,right:0,zIndex:1e3}).addClass("ui-igtrialwatermark")})})(jQuery);