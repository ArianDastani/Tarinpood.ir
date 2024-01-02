'use strict';

var LANGUAGES = {
  "فارسی": {
    "columns": [
      "پایه",
      "پیشرفته",
      "قابلیت پیمایش",
      "نمایش درختی",
      "رتبه بندی",
      "فرم ها",
      "جداول",
      "پایه",
      "پیشرفته",
      "قابلیت پیمایش",
      "نمایش درختی",
      "رتبه بندی",
      "فرم ها",
      "جداول"
    ],
    "heading": "ناوبری زیر استاتیک",
  },
  "انگلیسی": {
    "columns": [
      "Base",
      "Advance",
      "scrollable",
      "Tree View",
      "Rating",
      "News",
      "Tables",
      "Base",
      "Advance",
      "scrollable",
      "Tree View",
      "Rating",
      "News",
      "Tables"
    ],
    "heading": "Static Sub Nav",
  },
  "آلمانی": {
    "columns": [
      "Basis",
      "Fortschritt",
      "scrollable",
      "Baumansicht",
      "Die Einschaltquote",
      "Nachrichten",
      "Tische",
      "Basis",
      "Fortschritt",
      "scrollable",
      "Baumansicht",
      "Die Einschaltquote",
      "Nachrichten",
      "Tische"
    ],
    "heading": "Statisches U-Boot Nav",
  },
  "عربی": {
    "columns": [
      "قاعدة",
      "يتقدم",
      "للتمرير",
      "عرض الشجرة",
      "تقييم",
      "أخبار",
      "الجداول",
      "قاعدة",
      "يتقدم",
      "للتمرير",
      "عرض الشجرة",
      "تقييم",
      "أخبار",
      "الجداول"
    ],
    "heading": "الملاحة الفرعية الثابتة",
  }
};

var LanguageSelector = function($element) {
  this.$element = $element;
  this.$languageListItem = null;
  this.$languageSelect = null;
  this.$languagePageHdg = null;
  this.chosenLanguage = null;
  this.isEnabled = false;
  this.init();
};

LanguageSelector.prototype.init = function() {
  this.createChildren()
      .enable();
  
  return this;
};

LanguageSelector.prototype.createChildren = function() {
  this.$languageListItem = this.$element.find('> li');
  this.$languageSelect = $('.js-languageSelect');
  this.$languagePageHdg = $('.js-languagePageHdg');
  
  return this;
};

LanguageSelector.prototype.removeChildren = function () {
    this.$languageListItem = null;
    this.$languageSelect = null;
    this.$languagePageHdg = null;
    
    return this;
};

LanguageSelector.prototype.enable = function() {
  if (this.isEnabled) {
      return this;
  }
  this.isEnabled = true;
  this.$languageSelect.on('change', $.proxy(this.changeLanguage, this));
  
  return this;
};

LanguageSelector.prototype.disable = function () {
    if (!this.isEnabled) {
        return this;
    }
    this.isEnabled = false;
    
    this.$languageSelect.off('change', $.proxy(this.changeLanguage, this));
    return this;
};

LanguageSelector.prototype.destroy = function () {
    this.disable()
        .removeChildren();
        
    return this;
};

LanguageSelector.prototype.changeLanguage = function() {
  var numListItems = this.$languageListItem.length;
  
  this.chosenLanguage = LANGUAGES[this.$languageSelect.find(':selected').val()];
  
  // set the language text for each list item
  for (var i = 0; i < numListItems; i++) {
    this.$languageListItem.eq(i).find('a').text(this.chosenLanguage.columns[i]);
  }
  
  // set the heading text
  this.$languagePageHdg.html(this.chosenLanguage.heading);
  
  // set the header background color
  this.$element.css({
    background: this.chosenLanguage.background
  });
  
  // set the header text color
  this.$languageListItem.find('a').css({
    color: this.chosenLanguage.color
  });


  return this;
};


$(document).ready(function() {
  var languageSelector = new LanguageSelector($('.js-languageList'));
});