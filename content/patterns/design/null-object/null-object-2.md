## Null Object design pattern

    function tree_size(node) {
        set sum = 1
        if node.left exists {
            sum = sum + tree_size(node.left)
        }
        if node.right exists {
            sum = sum + tree_size(node.right)
        }
        return sum
    }

https://en.wikipedia.org/wiki/Null_object_pattern