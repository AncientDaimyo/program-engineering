jQuery('#append').click(function () {
    jQuery('#test').append(function () {
      return $('<input type="text"></input>')
    });
  });
  
