  ( function() {
	$(document).ready( function() {

		var firstAccordion = true;
		var $oldElement;
		var $this;

		var log = function(msg) {
			console.log(msg);
		}

		function slideAccordion($element) {
			if( firstAccordion ){
				$element.stop().slideDown(200, function() {
					firstAccordion = false;
					$oldElement = $element;
				});
			}else{
				if( $element.css('display') != 'block' ){
					$oldElement.slideUp(200, function() {
						$element.stop().slideDown(200, function(){
							$oldElement = $element;
						});
					});
				}else{
					$oldElement.slideUp(200);
				}
			}
		}

		function isRetinaDisplay(){
			bool = false;
			if( window.devicePixelRatio > 1.5 )
				bool = true;
			return bool;
		}

		if( localStorage.getItem('backgroundImage') ){
			$('body').css({
				backgroundImage: 'url('+localStorage.getItem('backgroundImage')+')',
				backgroundSize: localStorage.getItem('backgroundSize')
			});
		}

		$('aside.toolbar').find('li.accordion').on('click', function(e) {
			var $this = $(this);
			slideAccordion($this.children('ul'));
		}).children('a').on('click', function(e){
			e.preventDefault();
		});

		$('aside.toolbar').find('li.tools').on('click', function(e) {
			var $this = $(this);
			slideAccordion($this.children('div'));
		}).children('a').on('click', function(e){
			e.preventDefault();
		});

		$('li.tools').find('div').on('click', function(e) {
			return false;
		});

		$('li.tools').find('img').on('click', function(e){
			
			var sizeX = $(this).data('x');
			var sizeY = $(this).data('y');
			var backgroundSize = $(this).data('x')+'px '+$(this).data('y')+'px';
			var src = $(this).attr('src');

			if( isRetinaDisplay() ){
				src = src.replace('.png', '_@2x.png')
				$('body').css({
					backgroundImage: 'url('+src+')',
					backgroundSize: backgroundSize
				});
			}else{
				$('body').css({
					backgroundImage: 'url('+src+')',
					backgroundSize: backgroundSize
				});
			}

			localStorage.setItem('backgroundImage', src);
			localStorage.setItem('backgroundSize', backgroundSize);
		});

		$('.header').find('li').each( function(){
			$(this).qtip({
				content: {
					text: $(this).data('qtip')
				},
				style: {
					tip: {
						corner: 'topMiddle',
						color: '#333',
						size: {
							x: 10,
							y: 10
						}
					},
					background: '#333',
					color: '#FFF',
					border: {
						width: 1,
						radius: 5,
						color: '#333'
					}
				},
				position: {
					corner: {
						target: 'bottomMiddle',
						tooltip: 'topMiddle'
					}
				}
			});
		});

		$('label.checkbox').on('click', function(){
			$this = $(this);
			if( $this.next().is(':checked') ){
				$this.next().attr('checked', false);
			}else{
				$this.next().attr('checked', true);
			}
		});

		$('label.radio').on('click', function(){
			$this = $(this);
			$this.next().attr('checked', true);
		});

		if( isRetinaDisplay() )
			$('body').append('<img src="images/arrow_@2x.png" width="50px" id="scrollTopImage">');
		else
			$('body').append('<img src="images/arrow.png" id="scrollTopImage">');

		$(document).scroll( function(e){
			if( $(this).scrollTop() >= 100 ){
				$('img#scrollTopImage').fadeIn();
			}else if( $(this).scrollTop() < 100 ){
				$('img#scrollTopImage').fadeOut();
			}
		});

		$('img#scrollTopImage').on('mouseover', function(){
			$(this).attr('src', $(this).attr('src').replace('arrow', 'arrow_hover'));
		}).on('mouseout', function(){
			$(this).attr('src', $(this).attr('src').replace('arrow_hover', 'arrow'));
		});

		$('img#scrollTopImage').on('click', function(){
			$('html, body').animate({
				scrollTop: 0
			}, 'linear');
		});

	});
})(jQuery);
