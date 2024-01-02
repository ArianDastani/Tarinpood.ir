(function($) {
  var substringMatcher = function(strs) {
    return function findMatches(q, cb) {
      var matches, substringRegex;
      matches = [];
      substrRegex = new RegExp(q, 'i');
      $.each(strs, function(i, str) {
        if (substrRegex.test(str)) {
          matches.push(str);
        }
      });
      cb(matches);
    };
  };
  var states = ['مرکزی', 'اردبیل', 'آذربایجان غربی', 'اصفهان', 'خوزستان',
  'ایلام', 'خراسان شمالی', 'هرمزگان', 'بوشهر', 'خراسان جنوبی', 'آذربایجان شرقی',
  'تهران', 'لرستان', 'گیلان', 'سیستان و بلوچستان', 'زنجان', 'مازندران', 'سمنان',
  'کردستان', 'چهارمحال و بختیاری', 'فارس', 'قزوین', 'قم',
  'البرز', 'کرمان', 'کرمانشاه', 'گلستان', 'خراسان رضوی', 'همدان',
  'چهارمحال و بختیاری', 'کهکیلویه و بویراحمد', 'یزد'
];
  $('#the-basics .typeahead').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
      },
      {
        name: 'states',
        source: substringMatcher(states)
      });
  var states = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.whitespace,
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    local: states
  });
  $('#bloodhound .typeahead').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
      },
      {
        name: 'states',
        source: states
      });
  var countries = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.whitespace,
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    prefetch: '../assets/js/typeahead/data/countries.json'
  });
  $('#prefetch .typeahead').typeahead(null, {
    name: 'countries',
    source: countries
  });
  var bestPictures = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    prefetch: './../assets/js/typeahead/data/films/post30.json',
    remote: {
      url: '../assets/js/typeahead/data/films/queries/%QUERY.json',
      wildcard: '%QUERY'
    }
  });
  $('#remote .typeahead').typeahead(null, {
    name: 'best-pictures',
    display: 'value',
    source: bestPictures
  });
  var nflTeams = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('team'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    identify: function(obj) { return obj.team; },
    prefetch: '../assets/js/typeahead/data/nfl3.json'
  });
  function nflTeamsWithDefaults(q, sync) {
    if (q === '') {
      sync(nflTeams.get('Detroit Lions', 'Green Bay Packers', 'Chicago Bears'));
    }
    else {
      nflTeams.search(q, sync);
    }
  }
  $('#default-suggestions .typeahead').typeahead({
        minLength: 0,
        highlight: true
      },
      {
        name: 'nfl-teams',
        display: 'team',
        source: nflTeamsWithDefaults
      });
  $('#custom-templates .typeahead').typeahead(null, {
    name: 'best-pictures',
    display: 'value',
    source: bestPictures,
    templates: {
      empty: [
        '<div class="empty-message">',
        'مورد منطبقی یافت نشد',
        '</div>'
      ].join('\n'),
      suggestion: Handlebars.compile('<div><span>{{value}}</span> ،“ {{year}}</div>')
    }
  });
  var nbaTeams = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('team'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    prefetch: '../assets/js/typeahead/data/nba.json'
  });
  var nhlTeams = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('team'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    prefetch: '../assets/js/typeahead/data/nhl.json'
  });
  $('#multiple-datasets .typeahead').typeahead({
        highlight: true
      },
      {
        name: 'nba-teams',
        display: 'team',
        source: nbaTeams,
        templates: {
          header: '<h3 class="league-name">تیم های لیگ برتر</h3>'
        }
      },
      {
        name: 'nhl-teams',
        display: 'team',
        source: nhlTeams,
        templates: {
          header: '<h3 class="league-name">تیم های لیگ دسته اول</h3>'
        }
      });
  $('#scrollable-dropdown-menu .typeahead').typeahead(null, {
    name: 'countries',
    limit: 10,
    source: countries
  });
  var arabicPhrases = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.whitespace,
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    local: [
      "ایران",
      "برزیل",
      "هند",
      "کانادا",
      "چین"
    ]
  });
  $('#ltr-support .typeahead').typeahead({
        hint: false
      },
      {
        name: 'arabic-phrases',
        source: arabicPhrases
      });
})(jQuery);